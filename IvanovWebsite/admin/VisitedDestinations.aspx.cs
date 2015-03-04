using System;
using Core;
using Core.Utilities;
using System.IO;

namespace IvanovWebsite.admin
{
    public partial class VisitedDestinations : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.ValidateAdminRole();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.PageTitle = "Visited Destinations";
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

        protected void DestinationsGrid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var Item = DestinationRepository.GetSingleVisitedDestination(e.Keys[0] as int?);
            if (!string.IsNullOrWhiteSpace(Item.Picture))
            {
                File.Delete(AppSettings.UploadFilePhysicalPath + Item.Picture);
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string Picture = null;
            if (PictureUploader.HasFile)
            {
                Picture = PictureUploader.FileName.ToAZ09Dash(true);
            }

            var R = new DestinationRepository();
            R.TSP_VisitedDestination(
                iud: 0,
                Caption: CaptionTextBox.Text,
                Picture: Picture,
                ShortDesc: ShortDescriptionTextBox.Text,
                Lat: LatTextBox.Text,
                Lng: LngTextBox.Text,
                IsPublished: IsPublishedCheckBox.Checked
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
                
                Session["Success"] = true;
                Response.Redirect(Request.Url.OriginalString);
            }
        }        
    }
}