    if (oAuthenticate.getTaskID(out m_oDataSet1, "uspgetTaskID"))
    {
      for (int iTaskid = 0; iTaskid < m_oDataSet1.Tables[0].Rows.Count; iTaskid++)
      {
       iroleID[iTaskid] = Convert.ToInt32(m_oDataSet1.Tables[0].Rows[iTaskid]["RoleID"].ToString());
        /* ... */
       }
    }
