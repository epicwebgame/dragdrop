using Newtonsoft.Json;
using System;

namespace JsonDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Result
            {
                User = new User { Id = "Id", Name = "Sathyaish" },
                Succeeded = true,
                Message = "The operation was successful."
            };

            var json = JsonConvert.SerializeObject(result);

            Console.WriteLine(json);


            var s = "{\"User\":{\"Id\":\"78f3ef62-045f-4fd0-ac83-7b9a8f987059\",\"UserName\":\"Sathyaish@gmail.com\",\"Email\":\"Sathyaish@gmail.com\"},\"Succeeded\":true,\"SuccessMessage\":\"User logged in successfully.\",\"FailureMessage\":null,\"Exception\":null}";
            var o = JsonConvert.DeserializeObject(s);

            Console.WriteLine(o.ToString());

            Console.ReadKey();
        }
    }

    class Result
    {
        public User User { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }

    class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
