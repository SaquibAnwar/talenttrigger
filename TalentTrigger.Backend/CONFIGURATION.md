# Configuration Guide

## Database Connection Setup

### For Development (User Secrets)

1. **Set up User Secrets** (recommended for development):
   ```bash
   cd TalentTrigger.Backend
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=db.sbiddnibfjfvdzwfjutf.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=YOUR_ACTUAL_PASSWORD;Pooling=false;Command Timeout=60;"
   dotnet user-secrets set "Hangfire:ConnectionString" "Host=db.sbiddnibfjfvdzwfjutf.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=YOUR_ACTUAL_PASSWORD;Pooling=false;Command Timeout=60;"
   ```

### For Production (Environment Variables)

Set these environment variables:

```bash
export ConnectionStrings__DefaultConnection="Host=db.sbiddnibfjfvdzwfjutf.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=YOUR_ACTUAL_PASSWORD;Pooling=false;Command Timeout=60;"
export Hangfire__ConnectionString="Host=db.sbiddnibfjfvdzwfjutf.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=YOUR_ACTUAL_PASSWORD;Pooling=false;Command Timeout=60;"
```

### For Docker/Container

Create a `.env` file (never commit this to git):

```env
ConnectionStrings__DefaultConnection=Host=db.sbiddnibfjfvdzwfjutf.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=YOUR_ACTUAL_PASSWORD;Pooling=false;Command Timeout=60;
Hangfire__ConnectionString=Host=db.sbiddnibfjfvdzwfjutf.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=YOUR_ACTUAL_PASSWORD;Pooling=false;Command Timeout=60;
```

## Security Notes

- ✅ **User Secrets**: Automatically ignored by git, perfect for development
- ✅ **Environment Variables**: Secure for production deployments
- ✅ **Azure Key Vault**: Recommended for Azure deployments
- ❌ **appsettings.json**: Never put real passwords here
- ❌ **Source Control**: Never commit sensitive data to git

## Current Setup

The application is configured to use placeholder values in `appsettings.json` and will look for real values in:
1. User Secrets (development)
2. Environment Variables (production)
3. Azure Key Vault (if configured) 