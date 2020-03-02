using EntitiesCL.Model;
using ServiceCL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace ServiceCL
{
    public class ContactService : IContactService
    {
        string APIEndpoint = string.Empty;
        public ContactService()
        {
            APIEndpoint = Convert.ToString(ConfigurationManager.AppSettings["EvolentProjectAssesmentWebAPIEndpoint"]);
        }
        public IEnumerable<Contact> getAllContacts()
        {
            IEnumerable<Contact> contacts = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(APIEndpoint);

                    var responseTask = client.GetAsync("GetAllContact");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Contact>>();
                        readTask.Wait();
                        contacts = readTask.Result;
                    }
                    else
                    {
                        contacts = Enumerable.Empty<Contact>();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return contacts;
        }
        public bool AddContact(Contact contact)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(APIEndpoint);
                    var postTask = client.PostAsJsonAsync<Contact>("addcontact", contact);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }        

        

        public Contact GetContact(int id)
        {
            Contact contact = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(APIEndpoint);
                    var responseTask = client.GetAsync("editcontact/" + id.ToString());
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Contact>();
                        readTask.Wait();
                        contact = readTask.Result;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return contact;
        }

        public bool EditContact(Contact contact)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(APIEndpoint);

                    var postTask = client.PostAsJsonAsync<Contact>("editcontact", contact);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteContact(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(APIEndpoint);
                    var deleteTask = client.GetAsync("deletecontact/" + id);
                    deleteTask.Wait();
                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
