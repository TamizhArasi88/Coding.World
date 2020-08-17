using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCRApp.Models
{
	/// <summary>
	/// Our New Data In will now put messages on ROW and China in the following format.
	/// Mainly, ReceivedUtc will now be part of Kafka Message Header and NOT part of the XmlPayload.
	/// Also we do NOT add Username, Token and Payload tags as part of the XmlPayload.
	/// Hence we need to accept messages in the right format to do our parsing.
	/// This class is taken from : VSS.Messaging : Framework/Common/KafkaMessage.cs
	/// </summary>
	public class KafkaMessage
	{
		public string Topic { get; set; }

		public int Partition { get; set; }

		public long Offset { get; set; }

		public object Key { get; set; }

		public object Value { get; set; }

		[JsonIgnore]
		public Dictionary<string, string> Headers { get; set; }
	}
}
