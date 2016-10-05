using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MvcCrudWithCodeFirst.Models
{
    public enum Proficiency
    {
        [Display(Name = "Yazılım")]
        Software,
        [Display(Name = "Veritabanı Yöneticisi")]
        DatabaseAdmin,
        [Display(Name = "Sistem Uzmanı")]
        System,
        [Display(Name = "Ön Yüz Tasarımı")]
        FrontEnd,
        [Display(Name = "SharePoint Uzmanı")]
        SharePoint
    }
}
