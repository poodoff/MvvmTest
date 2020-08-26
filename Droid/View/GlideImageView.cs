
using System;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Com.Bumptech.Glide;
using Com.Bumptech.Glide.Load.Engine;
using Com.Bumptech.Glide.Request;
using Java.Net;

namespace TopChartMvvm.Droid.View
{
    #region Glide version 4
    [Register("TopChartMvvm.GlideImageView")]
    public class GlideImageView : ImageView
    {
        enum DownScaleType
        {
            None,
            FixSize
        }

        public bool Circle { get; set; }

        private DownScaleType downScaleType = DownScaleType.None;

        private int downScale;
        private Drawable placeholder;

        public GlideImageView(Context context) :
            base(context)
        {
            Initialize();
        }

        public GlideImageView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
            ParseAttrs(attrs);
        }

        public GlideImageView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
            ParseAttrs(attrs);
        }

        private void ParseAttrs(IAttributeSet attrs)
        {
        }


        protected virtual void Initialize()
        {

        }

        public override void SetImageBitmap(Android.Graphics.Bitmap bm)
        {
            base.SetImageBitmap(bm);
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                _imageUrl = value;

                GlideClear();

                if (string.IsNullOrEmpty(value))
                {
                    if (placeholder != null)
                        this.SetImageDrawable(placeholder);
                }
                else
                {
                    if (value.ToLower().StartsWith("http://") || value.ToLower().StartsWith("https://"))
                    {
                        LoadWebImage(value);
                    }
                }
            }
        }

        void LoadWebImage(string value)
        {
#if DEBUG
            Console.WriteLine($"[GlideImageView] Loading image url:{value}");
#endif
            try
            {
                Glide
                   .With(this.Context)
                    .Load(new URL(value))
                    .Apply(GetRequestOptions())
                    .Into(this);
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"[GlideImageView] Error while loading url: {value}; Message {ex.Message}");
#endif
            }
        }


        private void GlideClear()
        {
            var activity = this.Context as Android.App.Activity;
            if (activity != null && !activity.IsFinishing && !activity.IsDestroyed)
                Glide.With(this.Context).Clear(this);
        }


        private RequestOptions GetRequestOptions()
        {
            var options = new RequestOptions();

            if (placeholder != null)
                options = options.Placeholder(placeholder);

            if (downScaleType == DownScaleType.FixSize)
                options = options.Override(downScale);

            if (Circle)
                options = options.CircleCrop();

            return options;
        }

        private RequestOptions GetRequestFileOptions()
        {
            var options = new RequestOptions();

            options.SkipMemoryCache(true);
            options.InvokeDiskCacheStrategy(DiskCacheStrategy.None);

            if (placeholder != null)
                options = options.Placeholder(placeholder);

            if (downScaleType == DownScaleType.FixSize)
                options = options.Override(downScale);

            if (Circle)
                options = options.CircleCrop();

            return options;
        }
    }

    #endregion
}
