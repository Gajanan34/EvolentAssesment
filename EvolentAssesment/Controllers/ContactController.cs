using EntitiesCL.Model;
using ServiceCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EvolentAssesment.Controllers
{
    public class ContactController : Controller
    {
        private IContactService iContactService;
        public ContactController(IContactService iContactService)
        {
            try
            {
                this.iContactService = iContactService;
            }
            catch (Exception)
            {

            }
        }

        public ActionResult Index()
        {
            IEnumerable<Contact> contacts = this.iContactService.getAllContacts();
            return View(contacts);
        }

        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = this.iContactService.AddContact(contact);
                    if (result)
                        return RedirectToAction("Index", "Contact");
                    else
                        return View(contact);
                }
                else
                {
                    return View(contact);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                return View(contact);
            }
        }

        public ActionResult EditContact(int id)
        {
            Contact contact = null;
            if (ModelState.IsValid)
            {
                contact = this.iContactService.GetContact(id);
                if (contact != null)
                    return View(contact);
                else
                    return View(contact);
            }
            else
            {
                return View(contact);
            }

        }

        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = this.iContactService.EditContact(contact);
                    if (result)
                        return RedirectToAction("Index", "Contact");
                    else
                        return View(contact);
                }
                else
                {
                    return View(contact);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<ActionResult> DeleteContact(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = this.iContactService.DeleteContact(id);
                    if (result)
                        return RedirectToAction("Index", "Contact");
                    else
                        return RedirectToAction("Index", "Contact");
                }
                else
                {
                    return RedirectToAction("Index", "Contact");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Contact");
            }
        }
    }
}
