using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.RecyclerView.Widget;
using BethanysPieShopMobile.Core.Model;
using BethanysPieShopMobile.Core.Repository;
using BethanysPieShopMobile.Utility;
using BethanysPieShopMobile.ViewHolders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BethanysPieShopMobile.Adapters
{
    public class PieAdapter : RecyclerView.Adapter
        //Adapter is an abstract base class,so we need to implement a couple of methods here to override.
    {
        private List<Pie> pies;
        private View itemView;

        //Constructor - passing all the local data to the adapter to work with. 
        public PieAdapter()
        {
            var PieRepository = new PieRepository();
            pies = PieRepository.GetAllPies();
        }

        public override int ItemCount => pies.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is PieViewHolder pieViewHolder) 
            {
                pieViewHolder.PieNameTextView.Text = pies[position].Name;
                
                var imageBitmap = ImageHelper.GetImageBitmapFromUrl(pies[position].ImageThumbnailUrl);
                pieViewHolder.PieImageView.SetImageBitmap(imageBitmap);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View ItemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PieViewHolder,parent, false);

            PieViewHolder pieViewHolder = new PieViewHolder(itemView);
            return pieViewHolder;
        }
    }
}