﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  //needed for Display annotation
     

    public partial class products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public products()
        {
            this.account = new HashSet<account>();
            this.order = new HashSet<order>();
        }
    
        public int id { get; set; }
        [Display(Name = "Sản Phẩm")]
        public string name { get; set; }

        [Display(Name = "Danh Mục")]
        public Nullable<int> category_id { get; set; }

        [Display(Name = "Giá")]
        public Nullable<double> price { get; set; }
        
        [Display(Name = "Ảnh")]
        public string thumbnail { get; set; }

        [Display(Name = "Kích Thước")]
        public string size { get; set; }

        [Display(Name = "Khối Lượng")]
        public Nullable<double> weight { get; set; }
        
        [Display(Name = "Ghi Chú")]
        public string note { get; set; }

        [Display(Name = "Ngày Tạo")]
        public Nullable<System.DateTime> created_at { get; set; }

        [Display(Name = "Ngày Sửa")]
        public Nullable<System.DateTime> update_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<account> account { get; set; }

        [Display(Name = "Danh Mục")]
        public virtual category category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> order { get; set; }
    }
}
