    public IEnumerable<QuestionViewModel> GetQUESTIONBANKs()
    {
        return from question in db.QUESTIONBANKs
                    join option in db.QUESTIONOPTIONS
                    on question.ID equals option.QID
                    into questonOptions
                    select new QuestionViewModel
                    {
                        Q = question.QUESTION,
                        A = questionOptions.First(o => o.ISANSWER).OPTIONTEXT,
                        Options = from o in questionOptions select o.OPTIONTEXT
                    };
          }
