using System.Web.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;
using Nop.Core.Domain.Customers;
using NopUI.Plugin.Widgets.Unit.Services;
//using NopUI.Plugin.Widgets.Unit.Models;
using NopUI.Plugin.Widgets.Unit.Domain;
using System.Collections.Generic;
using Nop.Web.Models.Customer;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.Orders;
using Nop.Services.Orders;
using Nop.Web.Framework.Kendoui;
using Nop.Admin.Controllers;
using Nop.Services.Localization;
using NopUI.Plugin.Widgets.Unit.Models;
using Nop.Web.Framework.Mvc;
using Nop.Services.Catalog;
using Nop.Services.Common;
using NopUI.Core.Domain;
namespace NopUI.Plugin.Widgets.Unit.Controllers
{
    [AdminAuthorize]
    public class WidgetsUnitController : BaseAdminController
    {
       
        #region Field
        private IUnitService _unitService;
        private readonly ILanguageService _languageService;
        private readonly ILocalizedEntityService _localizedEntityService;
        private IProductService _productService;
        private IGenericAttributeService _genericAttributeService; 
        #endregion

        #region Cotr
        public WidgetsUnitController(IUnitService unitService,
            ILanguageService languageService,
            ILocalizedEntityService localizedEntityService,
            IProductService productService,
            IGenericAttributeService genericAttributeService)
        {
            _unitService = unitService;
            _languageService = languageService;
            _localizedEntityService = localizedEntityService;
            _productService = productService;
            _genericAttributeService = genericAttributeService;
        } 
        #endregion



        #region Config
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            return View();
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(FormCollection form)
        {


            return Configure();
        } 
        #endregion

        #region public page
        /// <summary>
        /// public page
        /// </summary>
        /// <param name="widgetZone"></param>
        /// <param name="additionalData"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone, object additionalData = null)
        {
            var model = additionalData as Nop.Web.Models.Customer.CustomerNavigationModel;
            return View("~/Plugins/Widgets.SecondHand/Views/WidgetsSecondHand/PublicInfo.cshtml", model);
        } 
        #endregion


        #region Index of Manage
        /// <summary>
        /// Index of Manage
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Manage(DataSourceRequest command)
        {
            var trials = _unitService.GetAll();

            var gridModel = new DataSourceResult
            {
                Data = trials,
                Total = trials.Count
            };

            return Json(gridModel);
        } 


        #endregion

        #region Creat
        /// <summary>
        /// Creat
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Creat()
        {
            var model = new Models.UnitModel();
            //locales
            AddLocales(_languageService, model.Locales);
            return View(model);
        }
        [HttpPost]
        public ActionResult Creat(UnitModel model)
        {
            if (ModelState.IsValid)
            {
                var sm = new UnitEntity() { Name=model.Name,DisplayOrder=model.DisplayOrder};
                _unitService.Insert(sm);
                //locales
                UpdateLocales(sm, model);
                SuccessNotification("添加成功");
                return RedirectToAction("Manage");
                //SuccessNotification(_localizationService.GetResource("Admin.Configuration.Shipping.Methods.Added"));
                //return continueEditing ? RedirectToAction("EditMethod", new { id = sm.Id }) : RedirectToAction("Methods");
            }

            //If we got this far, something failed, redisplay form
            return RedirectToAction("Manage");
        } 
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(UnitModel model)
        {
            if (model.Id > 0) {
                var entity = _unitService.GetById(model.Id);
                entity.Name = model.Name;
                entity.DisplayOrder = model.DisplayOrder;
                _unitService.Update(entity);
            }
            return new NullJsonResult();
        } 
        #endregion

        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Delete(int Id)
        {
            if (Id > 0)
            {
                var entity = _unitService.GetById(Id);
                _unitService.Delete(entity);
            }
            return new NullJsonResult();
        } 
        #endregion

        #region Tools
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="model"></param>
        [NonAction]
        protected virtual void UpdateLocales(UnitEntity entity, UnitModel model)
        {
            foreach (var localized in model.Locales)
            {
                _localizedEntityService.SaveLocalizedValue(entity,
                                                                x => x.Name,
                                                                localized.Name,
                                                                localized.LanguageId);


            }
        } 
        #endregion

        #region  the Unit of a product (Content of Admin Tab With Product Tab 's Unit)
        /// <summary>
        /// the Unit of a product (Content of Admin Tab With Product Tab 's Unit)
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ActionResult ProductUnit(int productId)
        {
            var product = _productService.GetProductById(productId);
            int modelId= product.GetAttribute<int>(ProductAttributeNames.UnitId);
            var all = _unitService.GetAll();
            var selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem() { Text="无",Value="0"});
            foreach (var item in all)
            {
                selectItems.Add(new SelectListItem() { 
                 Text=item.Name,
                 Value=item.Id.ToString()
                });
            }
            ViewBag.selectItems = selectItems;
            return PartialView(new UnitSelectItem() { UnitId = modelId });
        } 
        #endregion

        /// <summary>
        /// Save a product's Unit
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductUnitSave(int UnitId,int productId)
        {
            var product = _productService.GetProductById(productId);
            try
            {
                _genericAttributeService.SaveAttribute(product, ProductAttributeNames.UnitId, UnitId);
                return Content("修改成功");
            }
            catch (System.Exception)
            {

                return Content("修改失败");
            }
            
        }
    }
    
}