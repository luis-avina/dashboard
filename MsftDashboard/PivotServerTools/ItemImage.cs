// Copyright (c) Microsoft Corporation. All rights reserved.

namespace PivotServerTools
{
    using System;


    public class ItemImage
    {
        // Constructors, Finalizer and Dispose
        //======================================================================

        public ItemImage()
        {
        }

        public ItemImage(string imageFilePath)
        {
            this.ImageFilePath = imageFilePath;
        }

        public ItemImage(Uri imageUrl)
        {
            this.ImageUrl = imageUrl;
        }


        // Public Properties
        //======================================================================

        public string ImageFilePath { get; set; }
        public Uri ImageUrl { get; set; }
    }

}
