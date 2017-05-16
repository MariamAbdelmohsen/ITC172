using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "A5Service" in code, svc and config file together.
public class A5Service : IA5Service
{
    Community_AssistEntities db = new Community_AssistEntities();

    public int PersonLogin(string email, string password)

    {
        int key = 0;
        int result = db.usp_Login(email, password);
        if (result != -1)
        {
            var PersonKey = (from k in db.People
                           where k.PersonEmail.Equals(email)
                           select k.PersonKey).FirstOrDefault();
            key = (int)PersonKey;
        }
        return key;

    }

      public bool PersonRegister(PersonInfo p)
    //int IA5Service.PersonRegister(PersonInfo p)
    {
        bool result = true;  
        int rev = db.usp_Register(p.PersonLastName, p.PersonFirstName, p.PersonEmail, p.PersonPassword, p.PersonApartmentNumber, p.PersonStreet, p.PersonCity, p.PersonState, p.PersonZipcode, p.PersonHomePhone, p.PersonWorkPhone);
        
        return result;

    
            }

    public List<GrantRequest> GetGrands(int PersonKey)
    {

        var gqs = from gq in db.GrantRequests
                  select gq;

        List<GrantRequest> gRequest = new List<GrantRequest>();

        foreach (GrantRequest gq in gqs)
        {
            GrantRequest gRequest1 = new GrantRequest();
            gRequest1.GrantRequestDate = gq.GrantRequestDate;
            gRequest1.PersonKey = gq.PersonKey;
            gRequest1.GrantTypeKey = gq.GrantTypeKey;
            gRequest1.GrantRequestExplanation = gq.GrantRequestExplanation;
            gRequest1.GrantRequestAmount = gq.GrantRequestAmount;

        }

        return gRequest;
    }


    //   public List<GrantReview> GetGrantReview(string grantRrview)
    public bool newGrant(GrantRequest gq, GrantReview gr)
    {
        bool result = true;

        try
        {
            db.GrantRequests.Add(gq);
            db.GrantReviews.Add(gr);
            db.SaveChanges();

        }

        catch
        {
            result = false;
        }

        return result;

    }

    //public List<GrantRequest> GetGrantRequest(int personKey)
     
   // public bool newGrand(GrantRequest gq, GrantReview gr)
    //{
     //   throw new NotImplementedException();
   // }

    // int IA5Service.PersonRegister(PersonInfo p)
    // {
    //    throw new NotImplementedException();
    //}

    // public bool newGrand(GrantRequest gq, GrantReview gr)
    //  {
    //        throw new NotImplementedException();
    //    }

    // public List<GrantRequest> GetGrands(int PersonKey)
    // {
    //     throw new NotImplementedException();
    //}
}
