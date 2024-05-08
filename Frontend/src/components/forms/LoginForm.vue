<template>
    <div class="flex flex-col justify-center items-center py-10">
        <div class="border border-black rounded-md py-8 px-16">
            <FormKit type="form" 
                :classes="{
                    message: 'text-red-500 text-sm',
                }"
                  :submit-attrs="{
                        inputClass: 'border border-black py-1 px-4 rounded-md hover:bg-black hover:text-white',
                        wrapperClass: 'border-none',
                    }"
            >
                <FormKit type="text" name="name" id="name" validation="required|not:Admin" label="Name"
                    placeholder="Tirila Patric" 
                    :classes="{
                        outer: 'mb-5',
                        label: 'block mb-1 font-bold text-sm',
                        inner: 'w-96 border border-gray-400 rounded-md mb-1 overflow-hidden focus-within:border-blue-500',
                        input: 'w-full h-8 px-3 border-none text-base text-gray-700 placeholder-gray-400',
                        help: 'text-xs text-gray-500',
                        message: 'text-red-500 text-sm'
                    }"    
                />

                <FormKit
                    type="password"
                    name="password"
                    value=""
                    label="Password"
                    help="Enter a new password"
                    validation="required"
                    :classes="{
                        outer: 'mb-5',
                        label: 'block mb-1 font-bold text-sm',
                        inner: 'w-96 border border-gray-400 rounded-md mb-1 overflow-hidden focus-within:border-blue-500',
                        input: 'w-full h-8 px-3 border-none text-base text-gray-700 placeholder-gray-400',
                        help: 'text-xs text-gray-500',
                        message: 'text-red-500 text-sm'
                    }"
                />
            </FormKit>
        </div>
    </div>
</template>

<script setup>
import { ref } from 'vue'

defineProps({
})

</script>

<style scoped>
    button, input:where([type='button']), input:where([type='reset']), input:where([type='submit']){
        background-color: red;
    }
</style>