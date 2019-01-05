using System.Collections.Generic;
using System.Linq;

namespace Match_Memory_Game
{
    public class ImagesLogic:BaseLogic
    {
        public List<ImageModel> GetAllImages()
        {
            return DB.Images.Select(i => new ImageModel
            {
                imageID = i.ImageID,
                imageName = i.ImageName,
            }).ToList();
        }



        public ImageModel GetOneImage(int id)
        {
            return DB.Images
                .Where(i => i.ImageID == id)
                .Select(i => new ImageModel
                {
                    imageID = i.ImageID,
                    imageName = i.ImageName,
                }).SingleOrDefault();
        }



        //public ImageModel AddImage(ImageModel imageModel)
        //{
        //    Image image = new Image
        //    {
        //        ImageName = imageModel.imageName,
        //        ImageID = imageModel.imageID,
        //    };
        //    DB.Images.Add(image);
        //    DB.SaveChanges();

        //    imageModel.imageID = image.ImageID;
        //    return GetOneImage(image.ImageID);

        //}

    }
}
