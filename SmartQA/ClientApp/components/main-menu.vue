<template>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <router-link class="navbar-brand" to="/">SmartQA</router-link>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
            <div class="navbar-nav">
                <router-link class="nav-item nav-link" to="/permission">Permission</router-link>
                <router-link class="nav-item nav-link" to="/reftables">Reference tables</router-link>

            </div>
        </div>
    </nav>
</template>

<script>    
    export default {
        components: {        
            
        },
        data: function() {
            return {}
        },
        methods: {
           
        }
    }
</script>
