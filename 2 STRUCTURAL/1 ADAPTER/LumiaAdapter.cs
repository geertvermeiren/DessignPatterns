using System;

namespace Lumia
{


    public class Lumia
{
    protected string ModelId;
    protected string Height;
    protected string Result;
  
    // Constructor
    public Lumia(string modelId)
    {
        this.ModelId = modelId;
    }

    public virtual void LoadData()
    {
        Console.WriteLine("\nMeat: {0} ------ ", this.ModelId);
    }
}

public class Adapter: Lumia
{

     private LumiaJSONAdaptee _lumiaJSONAdaptee;

    // Constructor
    public Adapter(string modelId)
        : base(modelId)
    {
    }

     public override void LoadData()
    {
       _lumiaJSONAdaptee= new LumiaJSONAdaptee();

       Result    = _lumiaJSONAdaptee.GetLumiaMobilesJSONSpecifications();      
      base.LoadData();
        Console.WriteLine(" lUMIA:", Result);
    }


}

}