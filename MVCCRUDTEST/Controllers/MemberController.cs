using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUDTEST.Models;
using Nelibur;

namespace MVCCRUDTEST.Controllers
{
    public class MemberController : Controller
    {
        private MemeberRepository repo = RepositoryHelper.GetMemeberRepository();
        // GET: Member
        public ActionResult Index(MemberIndexViewModel omodel)
        {
            omodel.Search();
            return View(omodel);
        }

        public ActionResult Edit(int Id = 0)
        {
            Memeber omember = repo.Find(Id);
            if (omember == null)
                omember = new Memeber();
            
            MemberItemViewModel oviewmodel = Tools.TinyMapperTools<Memeber, MemberItemViewModel>(omember);

            return View(oviewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MemberItemViewModel oviewmodel)
        {
            if(ModelState.IsValid)
            {
                Memeber omember = repo.Find(oviewmodel.Id);
                if (omember == null)
                    omember = new Memeber();

                omember = Tools.TinyMapperTools<MemberItemViewModel, Memeber>(oviewmodel);
                if(omember.Id == 0)
                    repo.Insert(omember);
                else
                    repo.Update(omember);

                return RedirectToAction("Index");
            }                        

            //MemberItemViewModel oviewmodel = Tools.TinyMapperTools<Memeber, MemberItemViewModel>(omember);

            return View(oviewmodel);
        }

        public ActionResult Delete(int Id)
        {
            Memeber omember = repo.Find(Id);
           

            repo.Delete(omember);

            return RedirectToAction("Index");
        }
    }
}