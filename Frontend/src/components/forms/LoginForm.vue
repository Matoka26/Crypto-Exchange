<template>
    <div class="flex flex-col justify-center items-center">
        <FormKit type="form">
            <FormKit type="text" name="name" id="name" validation="required|not:Admin" label="Name"
                placeholder="Tirila Patric" />

            <FormKit type="text" name="email" id="email" validation="required|not:Admin|email" label="Email"
                placeholder="patric@gmail.com" />


            <FormKit type="range" name="age" id="age" label="Age" value="25" validation="min:18|max:100"
                validation-visibility="live" min="18" max="100" step="1"
                />
        </FormKit>
    </div>
</template>

<script setup>
import { ref } from 'vue'

defineProps({
})

</script>

<style scoped>
    input{
        border: 1px solid black;
    }
    .formkit-input{
        border: 1px solid black;
    }
</style>