<style lang="" scoped>
    



</style>


<template>
    <li>
        <div class="comment">
            <div class="comment__avatar">
                <img alt="Image" src="img/avatar-round-2.png">
            </div>
            <div class="comment__body">
                <h5 class="type--fine-print">You</h5>
                <div class="comment__meta">
                    <span>{{datesent}}</span>
                </div>
                <p>
                    {{title}}
                </p>
                <p>
                    {{body}}
                </p>
            </div>
        </div>
    </li>
</template>

<script>
    export default {
        props:['title','body','datesent',''],
        name: '',
        data() {
            return {
                
            }
        }
    }
</script>

