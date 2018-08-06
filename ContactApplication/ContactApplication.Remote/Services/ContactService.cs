using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Serialization;
using ContactApplication.Interfaces.Model;
using ContactApplication.Remote.Interfaces;
using Newtonsoft.Json;

namespace ContactApplication.Remote.Services
{
    public class ContactService : IContactService
    {
        private string _apiUrl = "http://localhost:63346/api/contact";

        protected readonly HttpClient HttpClient = new HttpClient();


        public IEnumerable<ContactDto> Read()
        {
            var stream = HttpClient.GetStringAsync(_apiUrl).Result;
            return JsonConvert.DeserializeObject<List<ContactDto>>(stream);
        }

        public void Add(ContactDto contact)
        {
            var myContent = JsonConvert.SerializeObject(contact);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = HttpClient.PostAsync(_apiUrl, byteContent).Result;
        }

        public void Remove(ContactDto contact)
        {
            throw new NotImplementedException();
        }
    }
}