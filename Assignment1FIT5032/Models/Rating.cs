//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment1FIT5032.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Rating
    {
        public int Id { get; set; }
        [Range(1, 5, ErrorMessage = "Please Enter A Value Between 1 & 5")]
        public long Store_Rating { get; set; }
        [Required(ErrorMessage = "Please Enter A Comment")]
        public string Comment { get; set; }
        public string User_Id { get; set; }
        public int Store_Id { get; set; }
    }
}
