
var BaseComponent = {
    props: ['user_info'],
    methods: {
        sortBy: function (array, key) {
            return _.sortBy(array, key);
        },
        makeRequest: function (config) {
            var token = sessionStorage.getItem('auth_token');

            if (!_.isNil(token)) {
                _.set(config, ['headers', 'Authorization'], 'Bearer ' + token);
            }
            return $.ajax(config);
        }
    }
};

Vue.component('add-account-component', _.merge({}, BaseComponent, {
    template: '#add-account-form',
    data: function () {
        return {
            initialSum: 0,
            accountType: 'base'
        };
    },
    methods: {
        addAccount: function () {
            var self = this;
            
            self.makeRequest({
                method: 'POST',
                url: '/api/BankSystem/add',
                data: {
                    AccountType: self.accountType,
                    Email: self.user_info.Email
                }
            }).then(function (accountNumber) {
                return self.makeRequest({
                    method: 'POST',
                    url: '/api/BankSystem/' + accountNumber + "/update",
                    data: {
                        value: self.initialSum
                    }
                });
            }).then(function (resp) {
                self.$parent.$emit('updateAccountsList');
            });
        }
    }
}));

Vue.component('account-details-component', _.merge({}, BaseComponent, {
    template: '#account-details',
    data: function () {
        return {
            account: null,
            operations: []
        };
    },
    props: _.concat(BaseComponent.props, ['account_number']),
    methods: {
        close: function () {
            $('#myModal').modal('hide');
            this.$parent.$emit('closeDetails', null);
        }
    },
    mounted: function () {
        var self = this;

        self.makeRequest({
            method: 'GET',
            url: '/api/BankSystem/' + self.account_number + "/detail"
        }).then((data) => {
            data = JSON.parse(data);
            _.each(data.Operations, (operation) => {
                var d = new Date(parseInt(operation.OperationDate.match(/[0-9]+/i)[0]));
                operation.OperationDate = [d.getDate(), d.getMonth() + 1, d.getFullYear()].join('.');
                operation.OperationDate += ' ' + [d.getHours(), d.getMinutes(), d.getSeconds()].join(':');
            });
            self.operations = data.Operations;
            self.account = data.AccountObject;
            $('#myModal').modal('show');
        });
    }
}));

Vue.component('deposit-component', _.merge({}, BaseComponent, {
    template: '#deposit-component',
    data: function() {
        return {
            depositValue: 0
        };
    },
    props: ['account_number'],
    methods: {
        updateAccount: function (accountNumber, summ) {
            var self = this;

            self.makeRequest({
                method: 'POST',
                url: '/api/BankSystem/' + accountNumber + "/update",
                data: {
                    value: summ
                }
            }).then(() => {
                self.$parent.$emit('updateAccountsList');
            });
        },
        selectAccount: function (accountNumber) {
            this.$parent.$emit('closeDetails', accountNumber);
        },
        deleteAccount: function (accountNumber) {
            var self = this;

            self.makeRequest({
                method: 'GET',
                url: '/api/BankSystem/' + accountNumber + "/delete"
            }).then(() => {
                self.$parent.$emit('updateAccountsList');
            });
        }
    }
}));

Vue.component('account-list-component', _.merge({}, BaseComponent, {
    template: '#account-list',
    data: function () {
        return {
            accounts: [],
            selected_account: null
        };
    },
    methods: {
        updateList: function () {
            var self = this;

            self.makeRequest({
                method: 'GET',
                url: '/api/BankSystem/search',
                data: {
                    email: self.user_info.Email
                }
            }).then(resp => {
                self.accounts = JSON.parse(resp);
            });
        },
        selectAccount: function (accounntNumber) {
            this.selected_account = accounntNumber;
        }
    },
    mounted: function () {
        this.$on('updateAccountsList', this.updateList);
        this.$on('closeDetails', this.selectAccount);
        this.updateList();
    }
}));

Vue.component('auth-component', _.merge({}, BaseComponent, {
    template: '#auth-forms',
    data: function () {
        return {
            active: 'login',
            form: {
                firstname: '',
                lastname: '',
                email: '',
                password: '',
                confirm_password: ''
            }
        };
    },
    methods: {
        setActive: function (actionName) {
            this.active = actionName;
        },
        login: function (email, password) {
            var self = this;

            return self.makeRequest({
                method: 'POST',
                url: '/Token',
                data: {
                    'grant_type': 'password',
                    'username': email,
                    'password': password
                }
            }).then(function (data) {
                sessionStorage.setItem('auth_token', data.access_token);

                return self.makeRequest({
                    method: 'GET',
                    url: '/api/Account/UserInfo'
                });
            }).then(function (data) {
                self.$parent.$emit('setUserInfo', data);
            });
        },
        loginClickHandler: function () {
            this.login(this.form.email, this.form.password);
        },
        registerClickHandler: function () {
            this.register(this.form)
        },
        register: function (form) {
            var self = this;

            return this.makeRequest({
                method: 'POST',
                url: '/api/Account/Register',
                data: {
                    'Email': form.email,
                    'Password': form.password,
                    'ConfirmPassword': form.confirm_password,
                    'FirstName': form.firstname,
                    'SecondName': form.lastname
                }
            }).then(function (data) {
                self.login(form.email, form.password);
            });
        }
    },
    mounted: function () {
        
    }
}));

var app = new Vue({
    el: '#app',
    data: function () {
        return {
            user_info: null
        };
    },
    mounted: function () {
        var self = this;
        var token = sessionStorage.getItem('auth_token');

        if (!_.isNil(token)) {
            $.ajax({
                method: 'GET',
                url: '/api/Account/UserInfo',
                headers: {
                    'Authorization': 'Bearer ' + token
                }
            }).then(function (data) {
                self.user_info = data;
            });
        }
        self.$on('setUserInfo', function (userInfo) {
            self.user_info = userInfo;
        });
    },
    methods: {
        logout: function () {
            var self = this;
            var token = sessionStorage.getItem('auth_token');

            if (!_.isNil(token)) {
                $.ajax({
                    method: 'POST',
                    url: '/api/Account/Logout',
                    headers: {
                        'Authorization': 'Bearer ' + token
                    }
                }).then(function (data) {
                    self.user_info = null;
                    sessionStorage.removeItem('auth_token');
                });
            }
        }
    }
});
