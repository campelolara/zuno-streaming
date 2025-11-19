package br.unip.zunoapp;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class FormCadastro extends AppCompatActivity {

    private TextView texto_tela_login;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_form_cadastro);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        IniciarComponentes();

        texto_tela_login.setOnClickListener(v -> {
            Intent intent = new Intent(FormCadastro.this,FormLogin.class);
            startActivity(intent); //navega para a próxima tela
        });
    }

    private void IniciarComponentes(){
        texto_tela_login = findViewById(R.id.texto_tela_login);
    }
}