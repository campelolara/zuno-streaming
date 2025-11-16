package br.unip.zunoapp;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class FormLogin extends AppCompatActivity {
    private TextView texto_tela_cadastro;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_form_login);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        //adiciono um evento de click no textview
        //intent = msg utilizada para abrir outra tela
        //sai do formLogin pro FormCadastro
        texto_tela_cadastro.setOnClickListener(v -> {
            Intent intent = new Intent(FormLogin.this,FormCadastro.class);
            startActivity(intent); //navega para a próxima tela
        });
    }

    //metodo que liga a variavel ao componente de interface dela
    private void IniciarComponentes(){
        texto_tela_cadastro = findViewById(R.id.texto_tela_cadastro);
    }
}