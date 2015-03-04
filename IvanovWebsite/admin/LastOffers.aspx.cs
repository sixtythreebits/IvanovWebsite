using System;
using Core;
using Core.Utilities;
using System.IO;
using IvanovWebsite.Models;

namespace IvanovWebsite.admin
{
    public partial class LastOffers : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.ValidateAdminRole();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.PageTitle = "Last Offers";
            CheckSession();
        }

        void CheckSession()
        {
            if (Session["Success"] != null)
            {
                SuccessErrorControl1.ShowSuccess = true;
                Session.Remove("Success");
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string Picture = null;
            string PdfFile = null;

            if (PictureUploader.HasFile)
            {
                Picture = PictureUploader.FileName.ToAZ09Dash(true);
            }

            if (PdfUploader.HasFile)
            {
                PdfFile = PdfUploader.FileName.ToAZ09Dash(true);
            }

            var R = new OfferRepository();
            R.TSP_LastOffer(
                iud: 0,
                ShortDesc: ShortDescriptionTextBox.Text,
                Picture: Picture,
                PdfFile: PdfFile
            );
            if (R.IsError)
            {
                SuccessErrorControl1.ShowError = true;
            }
            else
            {
                if (PictureUploader.HasFile)
                {
                    PictureUploader.SaveAs(AppSettings.UploadFilePhysicalPath + Picture);
                }
                if (PdfUploader.HasFile)
                {
                    PdfUploader.SaveAs(AppSettings.UploadFilePhysicalPath + PdfFile);
                }
                Session["Success"] = true;
                Response.Redirect(Request.Url.OriginalString);
            }
        }

        protected void LastOffersGrid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var Item = OfferRepository.GetSingleLastOffer(e.Keys[0] as int?);
            if (Item != null)
            {
                if (!string.IsNullOrWhiteSpace(Item.Picture))
                {
                    File.Delete(AppSettings.UploadFilePhysicalPath + Item.Picture);
                }

                if (!string.IsNullOrWhiteSpace(Item.PdfFile))
                {
                    File.Delete(AppSettings.UploadFilePhysicalPath + Item.PdfFile);
                }
            }
        }
    }
}