using Novell.Directory.Ldap;
using System;

namespace MMIS.DomainLayer.Authentication
{
    /// <summary>
    /// A class that provides password verification against an LDAP store by attempting to bind.
    /// </summary>
    public class LdapAuthentication : IDisposable
    {
        private readonly LdapAuthenticationOptions _options;
        private readonly LdapConnection _connection;
        private bool _isDisposed = false;

        /// <summary>
        /// Initializes a new instance with the the given options.
        /// </summary>
        /// <param name="options"></param>
        public LdapAuthentication(LdapAuthenticationOptions options)
        {
            _options = options;
            _connection = new LdapConnection();
        }

        /// <summary>
        /// Cleans up any connections and other resources.
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _connection.Dispose();
            _isDisposed = true;
        }

        /// <summary>
        /// Gets a value that indicates if the password for the user identified by the given DN is valid.
        /// </summary>
        /// <param name="distinguishedName"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        //public bool ValidatePassword(string distinguishedName, string password)
        //{
        //    if (_isDisposed)
        //    {
        //        throw new ObjectDisposedException(nameof(LdapConnection));
        //    }

        //    if (string.IsNullOrEmpty(_options.Hostname))
        //    {
        //        throw new InvalidOperationException("The LDAP Hostname cannot be empty or null.");
        //    }

        //    _connection.Connect(_options.Hostname, _options.Port);

        //    try
        //    {
        //        _connection.Bind(distinguishedName, password);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //        return false;
        //    }
        //    finally
        //    {
        //        _connection.Disconnect();
        //    }
        //}

        public bool ValidatePassword(string distinguishedName, string password)
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(LdapConnection));
            }

            if (string.IsNullOrEmpty(_options.Hostname))
            {
                throw new InvalidOperationException("The LDAP Hostname cannot be empty or null.");
            }

            _connection.Connect(_options.Hostname, _options.Port);

            try
            {
                var accountName = string.IsNullOrWhiteSpace(_options.Domain) ? distinguishedName : $"{_options.Domain}\\{distinguishedName}";
                _connection.Bind(accountName, password);
                //_connection.Bind("DELTA\\AMURAMBA", password);
                return _connection.Bound;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _connection.Disconnect();
            }
        }
    }

    public class LdapAuthenticationOptions
    {
        /// <summary>
        /// Gets or sets the LDAP server host name.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets the TCP port on which the LDAP server is running. 
        /// </summary>
        public int Port { get; set; } = 389;

        /// <summary>
        /// Gets or sets the domain name to use as distinguished name in conjuction with the username
        /// </summary>
        public string Domain { get; set; }
    }
}
