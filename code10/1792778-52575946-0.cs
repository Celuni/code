    PropertySet ps = new PropertySet(
													ItemSchema.Subject,
													ItemSchema.InReplyTo,
													ItemSchema.Body,
													ItemSchema.DateTimeSent,
													ItemSchema.DisplayTo,
													ItemSchema.Importance,
													EmailMessageSchema.From,
													ItemSchema.UniqueBody, 
													ItemSchema.MimeContent, 
													ItemSchema.HasAttachments, 
													ItemSchema.Attachments
													);
	_email = EmailMessage.Bind(service, new ItemId(mailItem.itemID),ps);
