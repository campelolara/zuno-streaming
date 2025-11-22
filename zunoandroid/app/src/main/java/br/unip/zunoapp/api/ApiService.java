package br.unip.zunoapp.api;

import java.util.List;
import br.unip.zunoapp.models.Conteudo;
import retrofit2.Call;
import retrofit2.http.GET;
public interface ApiService {
    @GET("conteudo")
    Call<List<Conteudo>> getTodosConteudos();
    // vou adicionar outras chamadas quando api estiver teminada, como login e etc..
    // me lembrem se eu esquecer, please!!!
}