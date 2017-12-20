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