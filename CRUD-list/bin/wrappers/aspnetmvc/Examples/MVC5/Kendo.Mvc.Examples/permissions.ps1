$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule("IIS_IUSRS", "FullControl", "ContainerInherit,ObjectInherit", "None", "Allow")
$acl = Get-ACL "C:\inetpub\wwwroot"
$acl.AddAccessRule($accessRule)
Set-ACL -Path "C:\inetpub\wwwroot" -ACLObject $acl