<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <naks-person-count-chart />
            </div>
            <div class="col-md-6">
                <naks-valid-chart />
            </div>
        </div>
    </div>
</template>

<script>
    import NaksPersonCountChart from './charts/naks-person-count-chart'
    import NaksValidChart from './charts/naks-valid-chart'

    export default {
        name: "PermissionReportsDashboard",
        components: {
            NaksPersonCountChart,
            NaksValidChart
        }
    }
</script>

<style scoped>

</style>