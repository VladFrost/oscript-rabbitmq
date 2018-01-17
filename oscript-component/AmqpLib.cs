using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using RabbitMQ.Client;

namespace oscriptcomponent
{
	/// <summary>
	/// Класс для работы с RabbitMQ
	/// </summary>
	[ContextClass("КлиентRMQ", "RMQClient")]
	public class AmqpLib : AutoContext<AmqpLib>
	{
        public AmqpLib()
		{
		}

		/// <summary>
		/// Некоторое свойство только для чтения.
		/// </summary>
		[ContextProperty("СвойствоДляЧтения", "ReadonlyProperty")]
		public string ReadonlyProperty
		{
			get
			{
				return "MyValue";
			}
		}

		/// <summary>
		/// Некоторый конструктор
		/// </summary>
		/// <returns></returns>
		[ScriptConstructor]
		public static IRuntimeContextInstance Constructor()
		{
			return new AmqpLib();
		}
	}
}

