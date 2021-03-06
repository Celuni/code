    private static List<string> GetGroupMemberList(string groupGuid, string domainDns, bool recurse = false) {
        var members = new List<string>();
        var group = new DirectoryEntry($"LDAP://{domainDns}/<GUID={groupGuid}>", null, null, AuthenticationTypes.Secure);
        while (true) {
            var memberDns = group.Properties["member"];
            foreach (var member in memberDns) {
                if (recurse) {
                    var memberDe = new DirectoryEntry($"LDAP://{member}");
                    if (memberDe.Properties["objectClass"].Contains("group")) {
                        members.AddRange(GetGroupMemberList(
                            new Guid((byte[]) memberDe.Properties["objectGuid"].Value).ToString(), domainDns,
                            true));
                    } else {
                        members.Add(member.ToString());
                    }
                } else {
                    members.Add(member.ToString());
                }
            }
            if (memberDns.Count == 0) break;
            try {
                group.RefreshCache(new[] {$"member;range={members.Count}-*", "member"});
            } catch (System.Runtime.InteropServices.COMException e) {
                if (e.ErrorCode == unchecked((int) 0x80072020)) { //no more results
                    break;
                }
                throw;
            }
        }
        return members;
    }
