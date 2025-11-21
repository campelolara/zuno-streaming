package br.unip.zunoapp.api;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
public class RetrofitClient {
    // não podo usar o localhost para acessar a api, usar ip e porta!!!
    private static final String BASE_URL = "http://10.0.2.2:5000/api/";
    // mudar a base_url depois!!! essa dai é um supunhetorio!!!
    private static Retrofit retrofit = null;
    public static ApiService getApiService() {
        if (retrofit == null) {
            retrofit = new Retrofit.Builder()
                    .baseUrl(BASE_URL)
                    .addConverterFactory(GsonConverterFactory.create()) // olá a desgraça da conversão em gson ai!!!
                    .build();
        }
        return retrofit.create(ApiService.class);
    }
}