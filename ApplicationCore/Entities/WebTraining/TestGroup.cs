﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using StoreManager.Models;


namespace WebMathTraining.Models
{
  public class TestGroup : CatalogEntityModel
  {
    public TestGroup()
    {

    }

    public new int Id { get; set; }

    [MaxLength(128)]
    public string Name { get; set; }

    [MaxLength(512)]
    public string Description { get; set; }

    public DateTime LastUpdated { get; set; }



    [NotMapped]
    public DateTime LastUpdatedLocal { get { return LastUpdated.ToLocalTime(); } set { LastUpdated = value.ToUniversalTime(); } }


    public int TeamHeadId { get; set; }


    public string MembersInfo { get; set; }



    [NotMapped]
    public HashSet<long> MemberObjectIds
    {

      get

      {

        if (_memberObjectIds == null)

        {

          _memberObjectIds = new HashSet<long>();



          if (string.IsNullOrEmpty(MembersInfo)) return _memberObjectIds;

          foreach (var id in MembersInfo.Split('+'))

          {

            if (Int64.TryParse(id, out var objectId))

              _memberObjectIds.Add(objectId);

          }

        }



        return _memberObjectIds;

      }

      set

      {

        _memberObjectIds = value;

        MembersInfo = string.Empty;

        if (_memberObjectIds == null || !_memberObjectIds.Any()) return;

        foreach (var id in _memberObjectIds)

          MembersInfo += (String.IsNullOrEmpty(MembersInfo) ? "" : "+") + id;

      }

    }



    public string EnrolledSessionsInfo { get; set; }



    [NotMapped]
    public HashSet<long> EnrolledSessionIds
    {

      get

      {

        if (_enrolledSessionIds == null)

        {

          _enrolledSessionIds = new HashSet<long>();



          if (string.IsNullOrEmpty(EnrolledSessionsInfo)) return _enrolledSessionIds;

          foreach (var id in EnrolledSessionsInfo.Split('+'))

          {

            if (Int64.TryParse(id, out var objectId))

              _enrolledSessionIds.Add(objectId);

          }

        }



        return _enrolledSessionIds;

      }

      set

      {

        _enrolledSessionIds = value;

        EnrolledSessionsInfo = string.Empty;

        if (_enrolledSessionIds == null || !_enrolledSessionIds.Any()) return;

        foreach (var id in _enrolledSessionIds)

          EnrolledSessionsInfo += (String.IsNullOrEmpty(EnrolledSessionsInfo) ? "" : "+") + id;

      }

    }



    #region Data



    [NotMapped]private HashSet<long> _memberObjectIds;



    [NotMapped]private HashSet<long> _enrolledSessionIds;



    #endregion

  }

}