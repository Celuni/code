            DateTime currentTime = DateTime.Now;
            bool flag = false;
            if (currentTime.TimeOfDay >= todaysJob.STARTTIME)
            {
                if (todaysJob.IsEndingTommorow)
                {
                    flag = currentTime.DayOfWeek <= todaysJob.taskDayOfWeek || (currentTime.DayOfWeek == todaysJob.taskDayOfWeek + 1 && currentTime.TimeOfDay < todaysJob.ENDTIME);
                }
                else
                {
                    flag = currentTime.TimeOfDay < todaysJob.ENDTIME;
                }
            }
            if (flag)
            {
                //do the task
            }
