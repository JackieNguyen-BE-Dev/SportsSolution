using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent{
        private IStoreRepository _storeRepository;


        public NavigationMenuViewComponent(IStoreRepository storeRepository)
        {
            this._storeRepository = storeRepository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_storeRepository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
