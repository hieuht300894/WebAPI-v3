using WebAPI.Models.EF;

namespace WebAPI.Controllers
{
    public class ProductController : BaseController<eProduct>
    {
        public ProductController(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        //public override ActionResult Index()
        //{
        //    ViewBag.Product = Ok(new eProduct());
        //    ViewBag.Units = Instance.GetRepository<eUnit>().GetAllWithTitle();
        //    return base.Index();
        //}

        //public override ActionResult Detail(int? id)
        //{
        //    return base.Detail(id);
        //}

        //public override ActionResult Create()
        //{
        //    ViewBag.Units = Instance.GetRepository<eUnit>().GetItems();
        //    return base.Create();
        //}

        //public override ActionResult Edit(int? id)
        //{
        //    return base.Edit(id);
        //}

        //public override ActionResult Delete(int? id)
        //{
        //    return base.Delete(id);
        //}

        //public override ActionResult Pages(int? pageIndex)
        //{
        //    return base.Pages(pageIndex);
        //}

        //public override ActionResult CreateItem(DataRequest<eProduct> data)
        //{
        //    eUnit unit = Instance.GetRepository<eUnit>().FindItem(data.NewData.IDUnit) ?? new eUnit();
        //    data.NewData.UnitCode = unit.Code;
        //    data.NewData.UnitName = unit.Name;
        //    return base.CreateItem(data);
        //}

        //public override ActionResult EditItem(DataRequest<eProduct> data)
        //{
        //    if (data.NewData.IDUnit != data.OldData.IDUnit)
        //    {
        //        eUnit unit = Instance.GetRepository<eUnit>().FindItem(data.NewData.IDUnit) ?? new eUnit();
        //        data.NewData.UnitCode = unit.Code;
        //        data.NewData.UnitName = unit.Name;
        //    }
        //    return base.EditItem(data);
        //}
    }
}