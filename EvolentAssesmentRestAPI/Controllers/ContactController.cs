using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntitiesCL.Model;

namespace EvolentAssesmentRestAPI.Controllers
{
    public class ContactController : ApiController
    {
        [HttpGet]
        [Route("api/contact/getallcontact")]
        public IHttpActionResult GetAllContact()
        {
            IList<Contact> contacts = null;
            try
            {
                using (var evolentContext = new EvolentProjectAssessmentEntities())
                {
                    contacts = evolentContext.ContactDetails.Select(c => new Contact()
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        PhoneNumber = c.Phone,
                        Status = c.Status
                    }).ToList();
                }

                if (contacts != null && contacts.Count != 0)
                    return Ok(contacts);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }            
        }


        [HttpPost]
        [Route("api/contact/addcontact")]
        public IHttpActionResult AddContact([FromBody]Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");

                using (var evolentContext = new EvolentProjectAssessmentEntities())
                {
                    evolentContext.ContactDetails.Add(new ContactDetail()
                    {
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        Email = contact.Email,
                        Phone = contact.PhoneNumber,
                        Status = contact.Status
                    });

                    evolentContext.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/contact/editcontact/{id}")]
        public IHttpActionResult EditContact(int id)
        {
            Contact contact = new Contact();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid model");
                using (var evolentContext = new EvolentProjectAssessmentEntities())
                {
                    var existingContact = evolentContext.ContactDetails.Where(c => c.Id == id)
                                                        .FirstOrDefault<ContactDetail>();
                    if (existingContact != null)
                    {
                        contact.FirstName = existingContact.FirstName;
                        contact.LastName = existingContact.LastName;
                        contact.Email = existingContact.Email;
                        contact.PhoneNumber = existingContact.Phone;
                        contact.Status = existingContact.Status;
                        return Ok(contact);
                    }
                    else
                        return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Not a valid model");
            }
        }


        [HttpPost]
        [Route("api/contact/editcontact")]
        public IHttpActionResult EditContact([FromBody]Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid data");

                using (var evolentContext = new EvolentProjectAssessmentEntities())
                {
                    var existingContact = evolentContext.ContactDetails.Where(c => c.Id == contact.Id)
                                                                     .FirstOrDefault<ContactDetail>();

                    if (existingContact != null)
                    {
                        existingContact.FirstName = contact.FirstName;
                        existingContact.LastName = contact.LastName;
                        existingContact.Email = contact.Email;
                        existingContact.Phone = contact.PhoneNumber;
                        existingContact.Status = contact.Status;
                        evolentContext.SaveChanges();
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/contact/deletecontact/{id}")]
        public IHttpActionResult DeleteContact(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Not Valid Contact Id");

                using (var evolentContext = new EvolentProjectAssessmentEntities())
                {
                    var contact = evolentContext.ContactDetails
                        .Where(c => c.Id == id)
                        .FirstOrDefault();

                    evolentContext.Entry(contact).State = System.Data.Entity.EntityState.Deleted;
                    evolentContext.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
