using System;
using System.Diagnostics;
using Tesseract;
using Google.Apis.Services;
using Google.Apis.Discovery.v1;
using Google.Apis.Discovery.v1.Data;
using Google.Cloud.Vision.V1;
using System.Xml;
using Newtonsoft.Json;
using OCRApp.Models;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace OCRApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			//GetTextFromImage();
			//GetListOfAPIs();
			//GetImageTextUsingVisionApi();
			//GenerateRandomBytes(100);

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}

		private static void GetTextFromImage()
		{

			Console.WriteLine("Enter the path of image file :");
			var filePath = Console.ReadLine();
			if (!string.IsNullOrWhiteSpace(filePath))
			{
				try
				{
					using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
					{
						using (var img = Pix.LoadFromFile(filePath))
						{
							using (var page = engine.Process(img))
							{
								var text = page.GetText();
								Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());

								Console.WriteLine("Text (GetText): \r\n{0}", text);
								Console.WriteLine("Text (iterator):");
								using (var iter = page.GetIterator())
								{
									iter.Begin();
									do
									{
										do
										{
											do
											{
												do
												{
													if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
													{
														Console.WriteLine("<BLOCK>");
													}

													Console.Write(iter.GetText(PageIteratorLevel.Word));
													Console.Write(" ");

													if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
													{
														Console.WriteLine();
													}
												} while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

												if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
												{
													Console.WriteLine();
												}
											} while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
										} while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
									} while (iter.Next(PageIteratorLevel.Block));
								}
							}
						}
					}
				}
				catch (Exception e)
				{
					Trace.TraceError(e.ToString());
					Console.WriteLine("Unexpected Error: " + e.Message);
					Console.WriteLine("Details: ");
					Console.WriteLine(e.ToString());
				}

			}
		}

		private static void GetListOfAPIs()
		{
			// Create the service.
			var service = new DiscoveryService(new BaseClientService.Initializer
			{
				ApplicationName = "Sample",
				ApiKey = "XXXX",
			});

			// Run the request.
			Console.WriteLine("Executing a list request...");
			var result = service.Apis.List().ExecuteAsync().Result;

			// Display the results.
			if (result.Items != null)
			{
				foreach (DirectoryList.ItemsData api in result.Items)
				{
					Console.WriteLine(api.Id + " - " + api.Title);
				}
			}
		}

		private static void GetImageTextUsingVisionApi()
		{
			// Load an image from a local file.
			var image = Image.FromFile("./images/testjd.jpg");

			var client = ImageAnnotatorClient.Create();
			var response = client.DetectText(image);

			foreach (var annotation in response)
			{
				if (annotation.Description != null)
					Console.WriteLine(annotation.Description);
				break;
			}
		}

		public static byte[] GenerateRandomBytes(int length)
		{
			// Create a buffer
			byte[] randBytes;

			if (length >= 1)
			{
				randBytes = new byte[length];
			}
			else
			{
				randBytes = new byte[1];
			}

			// Create a new RNGCryptoServiceProvider.
			System.Security.Cryptography.RNGCryptoServiceProvider rand =
				 new System.Security.Cryptography.RNGCryptoServiceProvider();

			// Fill the buffer with random bytes.
			rand.GetBytes(randBytes);

			// return the bytes.
			return randBytes;
		}
	}
}
