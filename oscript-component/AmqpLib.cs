using RabbitMQ.Client;
using ScriptEngine.Machine.Contexts;

namespace oscriptcomponent
{
    /// <summary>
    /// Класс для работы с RabbitMQ
    /// </summary>
    [ContextClass("КлиентRMQ")]
    public class AmqpLib : AutoContext<AmqpLib>
    {
        private readonly IModel _rmqModel;

        public AmqpLib(IModel rmqModel)
        {
            _rmqModel = rmqModel;
        }

        [ContextMethod("ОтправитьСтроку")]
        public void PublishString(string messageText, string exchangeName, string routingKey = "")
        {
            if (routingKey == null)
            {
                routingKey = "";
            }

            // todo
            byte deliveryMode = 2;

            byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(messageText);

            var rmqMessageProperties = _rmqModel.CreateBasicProperties();
            rmqMessageProperties.ContentType = "text/plain";
            rmqMessageProperties.ContentEncoding = "string";
            rmqMessageProperties.DeliveryMode = deliveryMode;

            _rmqModel.BasicPublish(exchangeName, routingKey, rmqMessageProperties, messageBodyBytes);
        }
    }
}