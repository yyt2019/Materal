﻿using Materal.RabbitMQHelper.Model;
using RabbitMQ.Client;
using System.Linq;

namespace Materal.RabbitMQHelper
{
    public class RabbitMQServerHelper : BaseRabbitMQHelper
    {
        /// <summary>
        /// 服务MQ配置
        /// </summary>
        private readonly RabbitMQServerConfig _serverMQConfig;
        /// <summary>
        /// 通道
        /// </summary>
        private readonly IModel _channel;
        /// <inheritdoc />
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="config"></param>
        public RabbitMQServerHelper(RabbitMQServerConfig config) : base(config, 1, 1)
        {
            _serverMQConfig = config;
            IConnection connection = Connections.Keys.FirstOrDefault();
            if (connection != null)
            {
                _channel = Connections[connection].FirstOrDefault();
            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            byte[] body = _serverMQConfig.Encoding.GetBytes(message);
            _channel.BasicPublish(_serverMQConfig.ExchangeName, _serverMQConfig.RoutingKey, null, body);
        }
    }
}
