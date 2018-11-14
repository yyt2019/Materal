﻿using DotNetty.Buffers;
using DotNetty.Codecs.Http;
using DotNetty.Codecs.Http.WebSockets;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Materal.DotNetty.ServerDome
{
    public class WebSocketServerHandler : SimpleChannelInboundHandler<object>
    {
        const string WebsocketPath = "/websocket";
        WebSocketServerHandshaker handshaker;
        protected override void ChannelRead0(IChannelHandlerContext ctx, object msg)
        {
            switch (msg)
            {
                case IFullHttpRequest request:
                    HandleHttpRequest(ctx, request);
                    break;
                case WebSocketFrame frame:
                    HandleWebSocketFrame(ctx, frame);
                    break;
            }
        }

        public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();

        void HandleHttpRequest(IChannelHandlerContext ctx, IFullHttpRequest req)
        {
            if (!req.Result.IsSuccess)
            {
                SendHttpResponse(ctx, req, new DefaultFullHttpResponse(HttpVersion.Http11, HttpResponseStatus.BadRequest));
                return;
            }
            if (!Equals(req.Method, HttpMethod.Get))
            {
                SendHttpResponse(ctx, req, new DefaultFullHttpResponse(HttpVersion.Http11, HttpResponseStatus.Forbidden));
                return;
            }
            if ("/".Equals(req.Uri))
            {
                IByteBuffer content = WebSocketServerBenchmarkPage.GetContent(GetWebSocketLocation(req));
                var res = new DefaultFullHttpResponse(HttpVersion.Http11, HttpResponseStatus.OK, content);

                res.Headers.Set(HttpHeaderNames.ContentType, "text/html; charset=UTF-8");
                HttpUtil.SetContentLength(res, content.ReadableBytes);

                SendHttpResponse(ctx, req, res);
                return;
            }
            if ("/favicon.ico".Equals(req.Uri))
            {
                var res = new DefaultFullHttpResponse(HttpVersion.Http11, HttpResponseStatus.NotFound);
                SendHttpResponse(ctx, req, res);
                return;
            }

            // Handshake
            var wsFactory = new WebSocketServerHandshakerFactory(
                GetWebSocketLocation(req), null, true, 5 * 1024 * 1024);
            this.handshaker = wsFactory.NewHandshaker(req);
            if (this.handshaker == null)
            {
                WebSocketServerHandshakerFactory.SendUnsupportedVersionResponse(ctx.Channel);
            }
            else
            {
                this.handshaker.HandshakeAsync(ctx.Channel, req);
            }
        }

        void HandleWebSocketFrame(IChannelHandlerContext ctx, IByteBufferHolder frame)
        {
            switch (frame)
            {
                case CloseWebSocketFrame _:
                    handshaker.CloseAsync(ctx.Channel, (CloseWebSocketFrame)frame.Retain());
                    return;
                case PingWebSocketFrame _:
                    ctx.WriteAsync(new PongWebSocketFrame((IByteBuffer)frame.Content.Retain()));
                    return;
                case TextWebSocketFrame _:
                    ctx.WriteAsync(frame.Retain());
                    return;
                case BinaryWebSocketFrame _:
                    ctx.WriteAsync(frame.Retain());
                    break;
            }
        }

        static void SendHttpResponse(IChannelHandlerContext ctx, IFullHttpRequest req, IFullHttpResponse res)
        {
            // Generate an error page if response getStatus code is not OK (200).
            if (res.Status.Code != 200)
            {
                IByteBuffer buf = Unpooled.CopiedBuffer(Encoding.UTF8.GetBytes(res.Status.ToString()));
                res.Content.WriteBytes(buf);
                buf.Release();
                HttpUtil.SetContentLength(res, res.Content.ReadableBytes);
            }

            // Send the response and close the connection if necessary.
            Task task = ctx.Channel.WriteAndFlushAsync(res);
            if (!HttpUtil.IsKeepAlive(req) || res.Status.Code != 200)
            {
                task.ContinueWith((t, c) => ((IChannelHandlerContext)c).CloseAsync(),
                    ctx, TaskContinuationOptions.ExecuteSynchronously);
            }
        }

        public override void ExceptionCaught(IChannelHandlerContext ctx, Exception e)
        {
            Console.WriteLine($"{nameof(WebSocketServerHandler)} {0}", e);
            ctx.CloseAsync();
        }

        static string GetWebSocketLocation(IFullHttpRequest req)
        {
            bool result = req.Headers.TryGet(HttpHeaderNames.Host, out ICharSequence value);
            Debug.Assert(result, "Host header does not exist.");
            string location = value.ToString() + WebsocketPath;

            if (ServerSettings.IsSsl)
            {
                return "wss://" + location;
            }
            else
            {
                return "ws://" + location;
            }
        }
    }
}