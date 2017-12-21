
Vue.component('add-account-component',
    {
        template: '#add-account-form',
        data: function() {
            return {
                account: {
                    FirstName: '',
                    LastName: '',
                    Email: '',
                    AccountType: 'base'
                }
            };
        },
        methods: {
            addAccount: function() {
                $.ajax({
                    method: 'POST',
                    url: 'api/BankSystem',
                    data: this.account
                }).then(function (resp) {
                    console.log(resp);
                });
            }
        }
    });

Vue.component('deposit-component',
    {
        template: '<div claass="row">' +
                    '<input type="number" class="form-control" v-model="depositValue">' +
                    '<button type="button" class="btn btn-primary" @click="updateAccount(account_number, depositValue)">Update</button>' +
                    '<button type="button" class="btn btn-danger" @click="deleteAccount(account_number)">Delete</button>' +
                  '</div>',
        data: function() {
            return {
                depositValue: 0
            };
        },
        props: ['account_number'],
        methods: {
            updateAccount: function (accountNumber, summ) {
                $.ajax({
                    method: 'PUT',
                    url: 'api/BankSystem?accountNumber=' + accountNumber,
                    data: {
                        value: summ
                    }
                }).then(() => {

                });
            },
            deleteAccount: function (accountNumber) {
                $.ajax({
                    method: 'DELETE',
                    url: 'api/BankSystem?accountNumber=' + accountNumber
                }).then(() => {

                });
            }
        }
    });

Vue.component('account-list-component',
    {
        template: '#account-list',
        data: function () {
            return {
                accounts: []
            };
        },
        methods: {
            updateList: function () {
                $.ajax({
                    method: 'GET',
                    url: 'api/BankSystem'
                }).then(resp => {
                    this.accounts = JSON.parse(resp);
                });
            }
        },
        mounted: function() {
            this.updateList();
        }
    });

var app = new Vue({
    el: '#app',
    data: function () {
        return {
            logged: false,
            form: {
                firstname: '',
                lastname: '',
                email: '',
                password: '',
                confirm_password: ''
            },
            bankAccounts: []
        };
    },
    mounted: function() {
        
    },
    methods: {
        register: function() {
            $.ajax({
                method: 'POST',
                url: 'api/Account/Register',
                data: {
                    "Email": this.form.email,
                    "Password": this.form.password,
                    "ConfirmPassword": this.form.confirm_password
                }
            }).then(function (resp) {
                this.logged = true;
                return $.ajax({
                    method: 'GET',
                    url: 'api/BankSystem'
                });
            }).then(function(resp) {
                console.log();
            });
        }
    }
});
