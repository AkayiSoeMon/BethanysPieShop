using Android.App;
using Android.OS;
using Android.Widget;
using BethanysPieShopMobile.Core.Model;
using BethanysPieShopMobile.Core.Repository;
using BethanysPieShopMobile.Utility;

namespace BethanysPieShopMobile
{
    [Activity(Label = "PieDetailActivity")]
    public class PieDetailActivity : Activity
    {
        private PieRepository pieRepository;
        private Pie selectedPie;
        private ImageView pieImageView;
        private TextView pieNameTextView;
        private TextView shortDescriptionTextView;
        private TextView descriptionTextView;
        private TextView priceTextView;
        private EditText amountEditText;
        private Button addToCartButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.pie_detail);
            // Create your application here

            pieRepository = new PieRepository();
            selectedPie = pieRepository.GetPieById(1);
            FindViews();
            BindData();
        }

        private void BindData()
        {
            pieNameTextView.Text = selectedPie.Name;
            shortDescriptionTextView.Text = selectedPie.ShortDescription;
            descriptionTextView.Text = selectedPie.LongDescription;
            priceTextView.Text = "Price: " + selectedPie.Price;


            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(selectedPie.ImageThumbnailUrl);
            pieImageView.SetImageBitmap(imageBitmap);
        }

        private void FindViews()
        {
            pieImageView = FindViewById<ImageView>(Resource.Id.pieImageView);
            pieNameTextView = FindViewById<TextView>(Resource.Id.pieNameTextView);
            shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            priceTextView = FindViewById<TextView> (Resource.Id.priceTextView);
            amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            addToCartButton = FindViewById<Button>(Resource.Id.addToCartButton);

        }
    }
}