using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using RabbitMQ.Client;

namespace oscriptcomponent
{
	/// <summary>
	/// Класс Соединение
	/// </summary>
	[ContextClass("СоединениеRMQ", "ConnectionRMQ")]
	public class Connection : AutoContext<Connection>
	{
	
        public Connection()
		{
		}

		private IConnection RmqConnection;

		/// <summary>
		/// Пользователь
		/// </summary>
		[ContextProperty("Пользователь")]
		public string User { get; set; }

		
		/// <summary>
		/// 
		/// </summary>
		[ContextProperty("Пароль")]
		public string Pass { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ContextProperty("ВиртуальныйХост")]
		public string Vhost { get; set; }
	
		
		/// <summary>
		/// 
		/// </summary>
		[ContextProperty("Сервер")]
		public string Host { get; set; }
		
		
		/// <summary>
		/// Установить соединение
		/// </summary>
		/// <returns>Экземпляр КлиентRMQ</returns>
		[ContextMethod("Установить")]
		public AmqpLib Create()
		{
			var factory = new ConnectionFactory
			{
				UserName = User,
				Password = Pass,
				VirtualHost = Vhost,
				HostName = Host
			};

			RmqConnection = factory.CreateConnection();
			var rmqModel =  RmqConnection.CreateModel();
			
			return new AmqpLib(rmqModel);

		}
		
		/// <summary>
		/// Закрыть соединение
		/// </summary>
		[ContextMethod("Закрыть")]
		public void Close()
		{
		
			RmqConnection.Close();
			
		}
		
		
		/// <summary>
		/// Конструктор нового соединения
		/// </summary>
		/// <returns></returns>
		[ScriptConstructor]
		public static IRuntimeContextInstance Constructor()
		{
			return new Connection();
		}
	}
}

