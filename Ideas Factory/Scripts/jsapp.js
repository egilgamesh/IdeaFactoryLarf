var usrid = getCookie("userinfo");
new Vue({
    el: '#app',
    data: {
        results: [],
        editInput: {
            idea_id: "",
            idea_title: "",
            idea_description: "",
            idea_creation_time: "",
            userid: ""
        },
        formTitle: "Ideas properties",
        currentuser:""

    },
    mounted() {
        axios.get('/api/ideas/')
         .then(function (response) {
             this.results = response.data;
             console.log(usid);
         }.bind(this));
        console.log(usid);
    },
    methods: {
        //function to add data to table
        add: function () {
            this.formTitle = "Add New Idea";
            this.editInput.idea_id = 0;
            this.editInput.idea_title = "";
            this.editInput.idea_description = "";
            this.editInput.idea_creation_time = new Date();
            this.editInput.userid = usrid;
            console.log(usrid);

        },
        //function to handle data edition
        edit: function (index) {
            this.editInput = this.results[index];
            this.formTitle = "Edit The Idea";
            console.log(this.editInput);
            // this.results.splice(index, 1);
        },
        //function to update data
        update: function (index) {
            axios.put("/api/ideas/" + index, this.editInput).then(response => {
            }).catch(error => {
            })
        },
        //function to defintely delete data
        deplete: function (index) {
            fetch("/api/ideas/" + index, {
                method: "DELETE"
            });
            const ideaindex = this.results.findIndex(p => p.idea_id === index)
            this.results.splice(ideaindex, 1)
        },

        //////////////////////
        insertNewIdea: function () {
            const formData = this.editInput;
            axios.post('/api/ideas/', formData)
                                        .then(response => {
                                            axios.get('/api/ideas/')
                                             .then(function (response) {
                                                 this.results = response.data;
                                                 console.log(usid);
                                             }.bind(this));
                                            this.editInput.idea_id = 0;
                                            this.editInput.idea_title = "";
                                            this.editInput.idea_description = "";
                                            this.editInput.idea_creation_time = new Date();
                                            this.editInput.userid = usrid;
                                        });

        },
    }
});



$(function () {
    //initialize modal box with jquery
    $('.modal').modal();
});

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
