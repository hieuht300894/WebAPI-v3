using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.BLL;
using WebAPI.Models.OtherEF;

namespace WebAPI.Controllers
{
    public class BaseController<T> : ApiController where T : class, new()
    {
        protected UnitOfWork Instance;

        public BaseController(UnitOfWork unitOfWork)
        {
            Instance = unitOfWork;
        }

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetCode(String Prefix)
        {
            String bRe = Prefix.ToUpper() + DateTime.Now.ToString("yyyyMMdd");
            DateTime time = DateTime.Now;
            try
            {
                IEnumerable<T> lstTemp = await Instance.GetRepository<T>().GetItemsAsync();
                T Item = lstTemp.OrderByDescending<T, Int32>("KeyID").FirstOrDefault();
                if (Item == null)
                {
                    bRe += "0001";
                }
                else
                {
                    String Code = Item.GetObjectByName<String>("Code");
                    if (Code.StartsWith(bRe))
                    {
                        Int32 number = Int32.Parse(Code.Replace(bRe, String.Empty));
                        ++number;
                        bRe = String.Format("{0}{1:0000}", bRe, number);
                    }
                    else
                        bRe += "0001";
                }
                return Ok(bRe);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetItems()
        {
            try
            {
                IEnumerable<T> lstTemp = await Instance.GetRepository<T>().GetItemsAsync();
                //IList<T> lstResult = lstTemp.OrderBy<T, String>("Ten").ToList();
                List<T> lstResult = lstTemp.ToList();
                return Ok(lstResult);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetItemsPage(int? pageIndex)
        {
            if (!pageIndex.HasValue || pageIndex == 0 || pageIndex == 1)
                return Ok(await Instance.GetRepository<T>().GetItemsAsync(1));

            return Ok(await Instance.GetRepository<T>().GetItemsAsync(pageIndex.Value));
        }

        [HttpGet]
        public virtual async Task<IHttpActionResult> GetItem(Int32? id)
        {
            try
            {
                if (id == null)
                    return BadRequest();

                T item = await Instance.GetRepository<T>().FindItemAsync(id.HasValue ? id.Value : 0);
                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public virtual async Task<IHttpActionResult> AddEntries([FromBody] DataRequest<T>[] items)
        {
            try
            {
                if (items == null || items.Length == 0)
                    return BadRequest();

                Instance.BeginTransaction();
                Instance.GetRepository<T>().AddOrUpdate(items.Select(x => x.NewData).ToArray());
                await Instance.SaveChangesAsync();
                Instance.CommitTransaction();
                return Ok(items.Select(x => x.NewData).ToArray());
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public virtual async Task<IHttpActionResult> AddEntry([FromBody] DataRequest<T> item)
        {
            try
            {
                if (item == null)
                    return BadRequest();

                Instance.BeginTransaction();
                Instance.GetRepository<T>().AddOrUpdate(item.NewData);
                await Instance.SaveChangesAsync();
                Instance.CommitTransaction();
                return Ok(item.NewData);
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public virtual async Task<IHttpActionResult> UpdateEntries([FromBody] DataRequest<T>[] items)
        {
            try
            {
                if (items == null || items.Length == 0)
                    return BadRequest();

                Instance.BeginTransaction();
                Instance.GetRepository<T>().AddOrUpdate(items.Select(x => x.NewData).ToArray());
                await Instance.SaveChangesAsync();
                Instance.CommitTransaction();
                return Ok(items.Select(x => x.NewData).ToArray());
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public virtual async Task<IHttpActionResult> UpdateEntry([FromBody] DataRequest<T> item)
        {
            try
            {
                if (item == null)
                    return BadRequest();

                Instance.BeginTransaction();
                Instance.GetRepository<T>().AddOrUpdate(item.NewData);
                await Instance.SaveChangesAsync();
                Instance.CommitTransaction();
                return Ok(item.NewData);
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public virtual async Task<IHttpActionResult> DeleteEntries([FromBody] DataRequest<T>[] items)
        {
            try
            {
                if (items == null || items.Length == 0)
                    return BadRequest();

                Instance.BeginTransaction();
                Instance.GetRepository<T>().Remove(items.Select(x => x.OldData).ToArray());
                await Instance.SaveChangesAsync();
                Instance.CommitTransaction();
                return Ok();
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public virtual async Task<IHttpActionResult> DeleteEntry([FromBody] DataRequest<T> item)
        {
            try
            {
                if (item == null)
                    return BadRequest();

                Instance.BeginTransaction();
                Instance.GetRepository<T>().Remove(item.OldData);
                await Instance.SaveChangesAsync();
                Instance.CommitTransaction();
                return Ok();
            }
            catch (Exception ex)
            {
                Instance.RollbackTransaction();
                ModelState.AddModelError("Exception", ex);
                return BadRequest(ModelState);
            }
        }
    }
}