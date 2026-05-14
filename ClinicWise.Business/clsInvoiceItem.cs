using ClinicWise.Contracts.InvoiceItems;
using ClinicWise.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicWise.Business
{
    public class clsInvoiceItem
    {
        public enum enMode { AddNew, Update }
        public enMode Mode;

        public int ItemID { get; set; }
        public int InvoiceID { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int? VisitFeeID { get; set; }

        public clsInvoiceItem()
        {
            ItemID = -1;
            InvoiceID = -1;
            Description = string.Empty;
            Quantity = 0;
            UnitPrice = 0;
            TotalPrice = 0;
            VisitFeeID = -1;

            Mode = enMode.AddNew;
        }

        public clsInvoiceItem(
            int itemID, 
            int invoiceID, 
            string description, 
            int quantity, 
            decimal unitPrice, 
            decimal totalPrice, 
            int? visitFeeID)
        {
            ItemID = itemID;
            InvoiceID = invoiceID;
            Description = description;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
            VisitFeeID = visitFeeID;

            Mode = enMode.Update;
        }

        public static async Task<List<InvoiceItemDTO>> GetAllByInvoiceAsync(int invoiceID)
        {
            return await clsInvoiceItemData.GetAllByInvoiceAsync(invoiceID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _Update();
                default:
                    return false;
            }
        }

        private bool _Update()
        {
            throw new NotImplementedException();
        }

        private bool _AddNew()
        {
            ItemID = clsInvoiceItemData.AddNew(InvoiceID, Description, Quantity, UnitPrice, TotalPrice);
            return ItemID != -1;
        }
    }
}
