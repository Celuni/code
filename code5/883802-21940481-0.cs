    Font myFont = FontFactory.GetFont("Arial", 8, Font.NORMAL);
    string line1 = "First line of text" + "\n";                     
    string line2= "Second line of text" + "\n";
    string line3= "   Third Line of text";
    Paragraph p1 = new Paragraph();
    Phrase ph1 = new Phrase(line1, myFont);
    Phrase ph2 = new Phrase(line2, myFont);
    Phrase ph3 = new Phrase(line3, myFont);
    p1.Add(ph1);
    p1.Add(ph2);
    p1.Add(ph3);
    PdfPCell mycell = new PdfPCell(p1);
