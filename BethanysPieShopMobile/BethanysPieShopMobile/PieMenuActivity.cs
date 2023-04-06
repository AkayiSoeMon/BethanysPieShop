using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using BethanysPieShopMobile.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BethanysPieShopMobile
{
    [Activity(Label = "PieMenuActivity", MainLauncher = false)]
    public class PieMenuActivity : Activity
    {
        private RecyclerView pieRecyclerView;
        private RecyclerView.LayoutManager pieLayoutManager;
        private PieAdapter pieAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.pie_menu);
            pieRecyclerView = FindViewById<RecyclerView>(Resource.Id.pieMenuRecyclerView);

            //built-in linear LayoutManager and adapter
            pieLayoutManager = new LinearLayoutManager(this);
            pieRecyclerView.SetLayoutManager(pieLayoutManager);
            pieAdapter = new PieAdapter();
            pieRecyclerView.SetAdapter(pieAdapter);
        }
    }
}