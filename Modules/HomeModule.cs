using Nancy;
using ShoeStore;
using System.Collections.Generic;
using System;

namespace ShoeStore
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] =_=>
      {
        List<Store> allStores = Store.GetAll();
        return  View ["index.cshtml", allStores];
      };
      Get["/brands"] = _ =>
      {
        List<Brand> allBrands = Brand.GetAll();
        return View["brands.cshtml", allBrands];
      };
      Get["/stores"] = _ =>
      {
        List<Store> allStores = Store.GetAll();
        return View["stores.cshtml", allStores];
      };
      Get["/stores/new"] = _ =>
      {
        return View["store_form.cshtml"];
      };
      Post["/stores/new"] = _ =>
      {
        Store newStore = new Store(Request.Form["store-name"]);
        newStore.Save();
        List<Store> allStores = Store.GetAll();
        return View["stores.cshtml", allStores];
      };
      Get["/brands/new"] = _ =>
      {
        List<Store> allStores = Store.GetAll();
        return View["brand_form.cshtml", allStores];
      };
      Post["/brands/new"] = _ =>
      {
        Brand newBrand = new Brand(Request.Form["brand-name"]);
        newBrand.Save();
        Store newStore = Store.Find(Request.Form["store-id"]);
        newBrand.AddStore(newStore);
        List<Brand> allBrands = Brand.GetAll();
        return View["brands.cshtml", allBrands];
      };
      Post["/brands/delete"] = _ =>
      {
        Brand.DeleteAll();
        List<Brand> allBrands = Brand.GetAll();
        return View["brands.cshtml", allBrands];
      };
      Get["/brands/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Brand selectedBrand = Brand.Find(parameters.id);
        List<Store> brandStores = selectedBrand.GetStore();
        List<Store> allStores = Store.GetAll();
        model.Add("brand", selectedBrand);
        model.Add("brandStores", brandStores);
        model.Add("allStores", allStores);
        return View["brand.cshtml", model];
      };
      Get["/stores/{id}"] = parameters =>
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Store selectedStore = Store.Find(parameters.id);
        List<Brand> storeBrands = selectedStore.GetBrand();
        List<Brand> allBrands = Brand.GetAll();

        model.Add("store", selectedStore);
        model.Add("storeBrands", storeBrands);
        model.Add("allBrands", allBrands);
        return View["store.cshtml", model];
      };
      Post["/stores/delete"] = _ =>
      {
        Store.DeleteAll();
        List<Store> allStores = Store.GetAll();
        return View["stores.cshtml", allStores];
      };
      Post["/brand/add_store"] = _ =>
      {
        Store store = Store.Find(Request.Form["store-id"]);
        Brand brand = Brand.Find(Request.Form["brand-id"]);
        brand.AddStore(store);
        List<Brand> allBrands = Brand.GetAll();
        return View["brands.cshtml", allBrands];
      };
      Post["/store/add_brand"] = _ =>
      {
        Store store = Store.Find(Request.Form["store-id"]);
        Brand brand = Brand.Find(Request.Form["brand-id"]);
        store.AddBrand(brand);
        List<Store> allStores = Store.GetAll();
        return View["stores.cshtml", allStores];
      };
      Get["store/delete/{id}"] = parameters =>
      {
        Store selectedStore = Store.Find(parameters.id);
        return View["store_delete.cshtml", selectedStore];
      };

      Delete["store/delete/{id}"] = parameters =>
      {
        Store selectedStore = Store.Find(parameters.id);
        selectedStore.Delete();
        List<Store> allStores = Store.GetAll();

        return View["stores.cshtml", allStores];
      };
      Get["store/edit/{id}"] = parameters =>
     {
       Store selectedStore = Store.Find(parameters.id);
       return View["store_edit.cshtml", selectedStore];
     };

     Patch["store/edit/{id}"] = parameters =>
     {
       Store selectedStore = Store.Find(parameters.id);
       selectedStore.Update(Request.Form["store-name"]);
       List<Store> allStores = Store.GetAll();

       return View["stores.cshtml", allStores];
     };
    }
  }
}
