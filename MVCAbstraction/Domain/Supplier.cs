using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MVCAbstraction.Domain
{
     /*
   * Author: Kedrian James
   * Class that represents a
   * Supplier for 
   * Grocery Store
   */
        //[Serializable]
        public class Supplier
        {
            /*unique identifier for the supplier*/
            [Key]
             //[Required]
            [StringLength(10)]
            public string SupplierCode {get; set;}
            
            /*name of supplier*/
            [Required]
            [StringLength(20)]
          public string SupplierName { get; set; }


            /*street address for supplier*/
            [Required]
           public string StreetAddress {get; set;}


            /*parish adress for supplier*/
            [Required]
            [StringLength(50)]
            public string Parish { get; set; }

            public virtual ICollection<Product> Products { get; set; }


            ////constructor
            //public Supplier()
            //{
            //    supplierCode = null;
            //    supplierName = null;
            //    streetAddress = null;
            //    parish = null;
            //}



            ///*supplier code property*/
            //public string SupplierCode
            //{
            //    get { return supplierCode; }
            //    set { supplierCode = value; }
            //}

            ///*supplier name property*/
            //public string SupplierName
            //{
            //    get { return supplierName; }
            //    set { supplierName = value; }
            //}

            ///*Street Address Property*/
            //public string StreetAddress
            //{
            //    get { return streetAddress; }
            //    set { streetAddress = value; }
            //}

            ///* Parish Property*/
            //public string Parish
            //{
            //    get { return parish; }
            //    set { parish = value; }
            //}


            ///* validate method*/
            //public bool Validate()
            //{
            //    if (supplierCode == null) return false;
            //    if (supplierName == null) return false;
            //    if (streetAddress == null) return false;
            //    if (parish == null) return false;

            //    return true;
            //}


            ///*class object, to test for equality in 
            //the objects values*/
            //public bool Equals(Supplier supplier)
            //{

            //    if (!supplier.supplierCode.Equals(supplierCode))
            //        return false;

            //    if (!supplier.supplierName.Equals(supplierName))
            //        return false;

            //    if (!supplier.streetAddress.Equals(streetAddress))
            //        return false;

            //    if (!supplier.parish.Equals(parish))
            //        return false;

            //    //----------------
            //    return true; //all attributes are equal true returned
            //}

        }//end class
    
}
