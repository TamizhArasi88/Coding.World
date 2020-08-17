using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OCRApp.Models
{
	public class DataInMessage
	{
		public string Token { get; set; }
		public string UserName { get; set; }
		public XElement Payload { get; set; }
		public DateTime ReceivedUtc { get; set; }
	}
}
